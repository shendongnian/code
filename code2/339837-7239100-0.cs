    void UpdateCaption(int Id, string oldName, string newName) {
        db.StartTran();
        db.Exec(string.format("update Commodity set CommodityCaption = '{0}' 
                where commodityId = {1}", oldName, Id));
        List<CommodityImage> images = CommodityImages.Where(ci => ci.CommodityID = Id);
        foreach (var img in images) 
           img.CommodityImageName = img.CommodityImageName.Replace(oldName, newName);
        db.SubmitChanges();
        db.CommitTran();
    }
