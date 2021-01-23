    list<item> recurseMe(list<category> parameters, item building)
    {
      if (parameters.isEmpty())
      {
        return item;
      }
      category param = parameters[0];
      list<item> ret = new list<item>();
      for(int i = 0; i < param.possibleValues; i++)
      {
        ret.add(recurseMe(parameters without param, item with param[i]);
      }
      return ret;
    }
