        foreach (var item in total)
        {
            if(item.GetType() == typeof(GeneralPost))
            {
                var record = (item as GeneralPost);
                Console.WriteLine($"{record.PostID}\tnull\t{record.PostDescription}\tnull");
            }
            else
            {
                var record = (item as EnquiryProduct);
                Console.WriteLine($"null\t{record.BusinessId}\tnull\t{record.ProductDescription}");
            }
        }
