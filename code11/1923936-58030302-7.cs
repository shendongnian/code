    Material myMat;
    public List<Texture2D> texes;
    IEnumerator Start()
    {
        yield return null;
        myMat = GetComponent<Renderer>().material;
        Texture2DArray texArr = new Texture2DArray(256, 256, 9, 
                TextureFormat.RGBA32, false, true);
        texArr.filterMode = FilterMode.Point;
        texArr.wrapMode = TextureWrapMode.Clamp;
        for (int i = 0 ; i < texes.Count ; i++)
        {
            texArr.SetPixels(texes[i].GetPixels(), i, 0);
        }
        texArr.Apply();
        myMat.SetTexture("_MainTexArray", texArr);
    }
