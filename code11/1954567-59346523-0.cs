public GameObject[] Cameras;
public void ActivateCamera(int index)
{
    for (int i = 0; i < Cameras.Length; i++)
    {
        if (i == index)
        {
            Cameras[i].SetActive(true);
        }
        else
        {
            Cameras[i].SetActive(false);
        }
    }
}
