csharp
public void OnCollisionEnter(Collision col)
{
    Debug.Log("Collision Enter!");
    Debug.Log(col.gameObject.name);
}
public void OnCollisionExit(Collision col)
{
    Debug.Log("Collision Exit!");
    Debug.Log(col.gameObject.name);
}
