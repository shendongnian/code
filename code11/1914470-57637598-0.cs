    using System;
    using UnityEngine;
    using UnityEngine.Playables;
    using UnityEngine.Animations;
    
    // Token: 0x02000002 RID: 2
    [RequireComponent(typeof(Animator))]
    public class AnimBg : MonoBehaviour
    {
        // Token: 0x04000001 RID: 1
        [SerializeField]
        private AnimationClip clip;
    
        // Token: 0x04000002 RID: 2
        [SerializeField]
        private float animspeed;
        
        private PlayableGraph graph;
        private AnimationClipPlayable playable;
        private AnimationMixerPlayable mixer;
        // Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000458
        private void Start()
        {
            graph = PlayableGraph.Create();
            AnimationClipPlayable b = AnimationClipPlayable.Create(graph, clip);
            b.SetSpeed(animspeed);
    
            mixer = AnimationMixerPlayable.Create (graph);
            mixer.ConnectInput (0, b, 0);
            mixer.SetInputWeight (0, 1);
    
            var output = AnimationPlayableOutput.Create (graph, "output", GetComponent<Animator> ());
            output.SetSourcePlayable (mixer);
            graph.Play ();
        }
    }
