    static IEnumerable<Asset> ToAssets(IDataReader rdr) {
       CheckReaderFormat(rdr);
       var h = this.DebugAsset;
       while (rdr.Read()) {
          var a = new Asset(rdr);
          if (h != null) h(a);
          yield return a;
       }
    }
    public event EventHandler<Asset> DebugAsset;
