    String[] ValidItems = {"alt", "src", "width", "height", "align", "border", "hspace", "longdesc", "vpace"};
    
    Dictionary<String, String> MispeltItems = { {"al", "alt" } };
    
    for(int i = ImgTagAttributes-1; i >= 0; i--)
    {
        var element = ImgTagAttributes[i];
        if(!ValidItems.Contains(element))
        {
            if(MispeltItems.ContainsKey(element))
            {
                ImgTagElements.Replace(element, MispeltItems[element].Value);
                //Or use remove and insert.
            }
            else
            {
                ImgTagElements.RemoveAt(i);
            }
        }
    }
