    public ActionResult TreeListExport()
            {
                List<Asset> oAsset = new List<Asset>();
    
                oAsset.Add(new Asset {AssetId =1, AssetName ="computer"});
                oAsset.Add(new Asset {AssetId =1, AssetName ="keyboard"});
                oAsset.Add(new Asset {AssetId =1, AssetName ="mouse"});
    
                MyClass.AssetList = oAsset;
    
                return View();
            }
