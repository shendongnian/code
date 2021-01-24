[System.Serializable]
public class GiftDetail
{
    public int GDetailValue;
    public string GDetailName;
    public double GDetailWeight;
    public int GDetailAmount;
}
[System.Serializable]
public class Gift
{
    public int GValue;
    public string GName;
    public List<GiftDetail> GiftDetails; // Added 's'
}
you can
GiftDetail NewGiftDetail = new GiftDetail
{
	GDetailValue = DropDownValueGiftDetail,
	GDetailAmount = iAmount,
	GDetailName = ifGiftDetailName.text,
	GDetailWeight = Fweight,
};
GiftDetail NewGiftDetail2 = new GiftDetail
{
	//(...)
};
Gift NewGift = new Gift  //Gift - not gifts
{
	GValue = 1,
	GName = "One",
	GiftDetails = new List<GiftDetail>() { NewGiftDetail, NewGiftDetail2 }
};
GiftDetail d3 = new GiftDetail
{
	//(...)
};
NewGift.GiftDetails.Add(d3);
