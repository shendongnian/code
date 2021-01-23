    for (int i = 0; i < ReviewList.Count; i++)
    {
        string serviceCode = ReviewList[i].SERVICE.SERVICE_DESC;
        ReviewList[i].SERVICE.SERVICE_DESC = "star" + serviceCode.Length + ".png";
    }
