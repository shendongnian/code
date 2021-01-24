C#
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
class MomentumMovement : MonoBehaviour
{
    public GameObject playerCamera;
    public GameObject playerModel;
    CharacterController controller;
    float speed = 400f;
    Vector3 lastVelocity;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        lastVelocity = controller.velocity;
    }
    Vector3 ScaleDirectionVector(Vector3 direction)
    {
        float multiplier = 1 / (Mathf.Abs(direction.x) + Mathf.Abs(direction.z));
        return new Vector3(
            direction.x * multiplier,
            0,
            direction.z * multiplier
        );
    }
    void Move()
    {
        Vector3 moveVector = ScaleDirectionVector(playerCamera.transform.forward) * Input.GetAxis("Vertical");
        moveVector += ScaleDirectionVector(playerCamera.transform.right) * Input.GetAxis("Horizontal");
        moveVector *= speed * Time.deltaTime;
        controller.SimpleMove(moveVector);
        playerModel.transform.position = transform.position;
    }
    void RotateToVelocity()
    {
        Vector3 lookAt = transform.position + controller.velocity.normalized;
        Vector3 targetPosition = new Vector3(lookAt.x, transform.position.y, lookAt.z);
        if (targetPosition - transform.position != Vector3.zero)
        {
            Quaternion q = Quaternion.LookRotation(targetPosition - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 500 * Time.deltaTime);
        }
    }
    Vector3 CalculateTilt(Vector3 acceleration)
    {
        Vector3 tiltAxis = Vector3.Cross(acceleration, Vector3.up);
        tiltAxis.y = 0;
        Quaternion targetRotation = Quaternion.AngleAxis(30, tiltAxis) * transform.rotation;
        return targetRotation.eulerAngles;
    }
    void TiltToAcceleration()
    {
        Vector3 centerOfMass = controller.center + controller.transform.position;
        Vector3 acceleration = controller.velocity / Time.deltaTime - lastVelocity;
        Vector3 tilt = CalculateTilt(acceleration);
        Quaternion targetRotation = Quaternion.Euler(tilt);
        playerModel.transform.rotation = Quaternion.Lerp(playerModel.transform.rotation, targetRotation, 10 * Time.deltaTime);
    }
    void FixedUpdate()
    {
        Move();
        RotateToVelocity();
        TiltToAcceleration();
        lastVelocity = controller.velocity / Time.deltaTime;
    }
}
I ended up calculating the axis on which to rotate (which is the cross product between the "up" direction of the world and the acceleration vector) and manually rotating the model 30 degrees on it.<br><br>
Now this was something I have tried before, but the meat of the problem was in this line:
C#
Quaternion targetRotation = Quaternion.Euler(transform.eulerAngles + tilt);
That was later changed to:
C#
Quaternion targetRotation = Quaternion.Euler(tilt);
Hope I helped anyone with my code!
