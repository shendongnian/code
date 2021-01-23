    public static void BulkUpdate<T>(IEnumerable<T> vos) where T : CommodityVO {
      foreach (var vo in vos) {
        Updater(vo);
      }
    }
