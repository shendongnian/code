c#
void OnCollisionEnter(Collider col)
{
    // Apaprently CompareTag is better for performance
    if (col.gameObject.CompareTag("DeathTerrain"))
    {
        Debug.Log($"This is where you die to {col.gameObject.name}");
    } else
    {
        Debug.Log($"Hit a game object named {col.gameObject.name} that didn't have the tag.");
    }
}
