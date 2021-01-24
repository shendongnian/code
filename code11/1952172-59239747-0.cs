bool allowModeChange=true;
...
void Update()
{
    if (Input.GetKeyDown("m"))
    {
        if (allowModeChange)
        {
            mode = !mode;
            allowModeChange = false;
        }
    }
    else
    {
        allowModeChange = true;
    }
    if (mode)
    {
        random();
    } 
    else 
    {
        round();
    }
}
`allowModeChange` prevents you to flip mode every frame while holding the m key.
