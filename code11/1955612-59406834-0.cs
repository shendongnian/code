using UnityEngine;
public class JVRLookAtRotation : MonoBehaviour, IJVRControllerInteract
{
    [SerializeField] private Transform toRotate;
    
    [SerializeField] private Vector3 minRotationDelta;
    [SerializeField] private Vector3 maxRotationDelta;
    private JVRController _jvrController;
    private bool _isGrabbed;
    private Vector3 _targetPosition;
    
    // No clue where does this come from
    private Vector3 _localRotationRangeCenter = new Vector3(0, 0.999f, 0.044f);
    private void LateUpdate()
    {
        
        if (!_isGrabbed) return;
        if (_jvrController.Grip + _jvrController.Trigger < Rules.GrabbingThreshold)
        {
            _isGrabbed = false;
            _jvrController.StopGrabbing();
            _jvrController = null;
            return;
        }
        Vector3 up = toRotate.up;
        Vector3 forward = toRotate.forward;
        Vector3 right = toRotate.right;
        Vector3 rotatePosition = toRotate.position;
        Vector3 pos1 = rotatePosition + up;
        Vector3 pos2 = rotatePosition + forward;
        Plane p = new Plane(rotatePosition, pos1, pos2);
        _targetPosition = p.ClosestPointOnPlane(_jvrController.CurrentPositionWorld);
        Vector3 worldRotationRangeCenter = toRotate.parent.TransformDirection(_localRotationRangeCenter);
        Vector3 targetForward = _targetPosition - rotatePosition;
        float targetAngle = Vector3.SignedAngle(worldRotationRangeCenter, targetForward, right);
        float clampedAngle = Mathf.Clamp(targetAngle, minRotationDelta.x, maxRotationDelta.x);
        Vector3 clampedForward = Quaternion.AngleAxis(clampedAngle, right) * worldRotationRangeCenter;
        
        toRotate.rotation = Quaternion.LookRotation(clampedForward, Vector3.Cross(clampedForward, right));
    }
    public void JVRControllerInteract(JVRController jvrController)
    {
        if (_isGrabbed) return;
        if (!(jvrController.Grip + jvrController.Trigger > Rules.GrabbingThreshold)) return;
        
        _jvrController = jvrController;
        _jvrController.SetGrabbedObject(this);
        _isGrabbed = true;
    }
}
