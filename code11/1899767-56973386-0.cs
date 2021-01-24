Vector3 hitPoint;
float speed = 5;
void Update()
{
    if (Input.GetMouseButton(0))
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float enter = 0.0f;
        if (m_Plane.Raycast(ray, out enter))
        {
            hitPoint = ray.GetPoint(enter);
            transform.position = Vector3.MoveTowards(transform.position, hitPoint, speed * Time.deltaTime);
        }
    }
}
