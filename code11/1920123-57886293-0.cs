using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
class TransformClip {
	AnimationCurve[] positionCurves;
	AnimationCurve[] rotationCurves;
	int curveCount = 3;
	static int clipCount = 1;
	public TransformClip() {
		positionCurves = new AnimationCurve[curveCount];
		rotationCurves = new AnimationCurve[curveCount];
		for (int i = 0; i < curveCount; i++) {
			positionCurves[i] = new AnimationCurve();
			rotationCurves[i] = new AnimationCurve();
		}
	}
	public void record(Transform transform, float recordTime) {
		float keyTime = Time.time - recordTime;
		for (int i = 0; i < curveCount; i++) {
			positionCurves[i].AddKey(keyTime, transform.position[i]);
			rotationCurves[i].AddKey(keyTime, transform.eulerAngles[i]);
		}
	}
	public AnimationClip stop() {
		AnimationClip clip = new AnimationClip();
		clip.SetCurve("", typeof(Transform), "localPosition.x", positionCurves[0]);
		clip.SetCurve("", typeof(Transform), "localPosition.y", positionCurves[1]);
		clip.SetCurve("", typeof(Transform), "localPosition.z", positionCurves[2]);
		clip.SetCurve("", typeof(Transform), "localRotation.x", rotationCurves[0]);
		clip.SetCurve("", typeof(Transform), "localRotation.y", rotationCurves[1]);
		clip.SetCurve("", typeof(Transform), "localRotation.z", rotationCurves[2]);
		return clip;
	}
	public void saveAnimation(AnimationClip clip, string clipName) {
		clipName = "Assets/" + clipName + " - " + clipCount + ".anim";
		AssetDatabase.CreateAsset(clip, clipName);
		AssetDatabase.SaveAssets();
		clipCount++;
	}
};
public class Record : MonoBehaviour {
	public bool isRecording;
	float recordStartTime;
	TransformClip transformClip;
	void Update() {
		if (Input.GetKeyDown(KeyCode.R) && !isRecording) {
			// Start recording.
			recordStartTime = Time.time;
			isRecording = true;
			transformClip = new TransformClip();
		}
		else if (Input.GetKeyDown(KeyCode.R) && isRecording) {
			// Stop recording.
			isRecording = false;
			AnimationClip clip = transformClip.stop();
			transformClip.saveAnimation(clip, "runtimeClip");
		}
		if (isRecording) {
			transformClip.record(transform, recordStartTime);
		}
	}
}
  [1]: https://docs.unity3d.com/ScriptReference/AnimationCurve.html
  [2]: https://docs.unity3d.com/ScriptReference/AnimationCurve.AddKey.html
  [3]: https://docs.unity3d.com/ScriptReference/AnimationClip.html
  [4]: https://docs.unity3d.com/ScriptReference/AnimationClip.SetCurve.html
  [5]: https://docs.unity3d.com/ScriptReference/AssetDatabase.CreateAsset.html
  [6]: https://docs.unity3d.com/ScriptReference/AssetDatabase.SaveAssets.html
