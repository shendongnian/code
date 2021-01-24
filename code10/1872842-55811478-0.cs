public IEnumerator colorlerpin7()
{
    float ElapsedTime = 0.0f;
    float TotalTime = 1f;
    Renderer matRenderer =  fluidpef.GetComponent<Renderer>();
    while (matRenderer.material.color.a > 0.0f)
    {
        ElapsedTime = Mathf.Clamp(ElapsedTime + Time.deltaTime, 0.0f, TotalTime);
        matRenderer.material.color = Color.Lerp(new 
        Color(1f, 1f, 1f, 1f), new Color(1f, 1f, 1f, 0f), (ElapsedTime / 
        TotalTime);
        yield return null;
    }
}
