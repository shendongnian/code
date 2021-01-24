public class GiftDetail
{
    public int GDetailValue { get; set; }
    public string GDetailName { get; set; }
    public double GDetailWeight { get; set; }
    public int GDetailAmount { get; set; }
}
public class Gift
{
    public int GValue { get; set; }
    public string GName { get; set; }
    public List<GiftDetail> GiftDetails { get; set;  } // Added 's'
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
