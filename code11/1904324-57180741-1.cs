void Rotation()
{
    RotateX = Input.GetAxis("Mouse X") * RorationSpeed;
    RotateY = Input.GetAxis("Mouse Y") * RorationSpeed;
    RotateY = Mathf.Clamp(RotateY, MinYAxis, MaxYAxis);
    Camera.transform.Rotate(new Vecto3(-RotateY, 0f, 0f));
    transform.Rotate(new Vector3(0f, RotateX, 0f));
}
