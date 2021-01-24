    UnityEngine.UI.Text[] myTexts;
    void OptimiseTextSizes()
    {
        int minSize = 999;
        foreach (UnityEngine.UI.Text t in myTexts)
        {
            if (t.cachedTextGenerator.fontSizeUsedForBestFit < minSize)
            {
                minSize = t.cachedTextGenerator.fontSizeUsedForBestFit;
            }
        }
        foreach (UnityEngine.UI.Text t in myTexts)
        {
            t.resizeTextMaxSize = minSize;
        }
    }
