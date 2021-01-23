    public List<Item_Img_Sal_VIEW> GetItemDescription(int ItemNo) 
            {
                var Result= db.Item_Img_Sal_VIEW.Where(p => p.ItemID == ItemNo).ToList();
                return Result.Distinct().ToList();
            }
