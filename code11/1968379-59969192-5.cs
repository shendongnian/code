      ...
      IDictionary<Player, IList<Attribute>> dictionary = new Dictionary<Player, IList<Attribute>>();
      dictionary.Add(
        player("Lebron James"), 
        attribute("mid height", "mid weidght", "high vertical")
      );
    }
    private Player player(string name){
      return new Player(name);
    }
    private IList<Attribute> attribute(params string[] strAttributes){
      IList<Attribute> resultList = new List<Attribute>();
      foreach(string strAttr in strAttributes){
        resultList.Add(new Attribute(strAttr));
      }
      return resultList;
    }
