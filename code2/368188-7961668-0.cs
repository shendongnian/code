    private IList DeserializeList(int depth)
    {
      IList list = (IList) new ArrayList();
      char? nullable1 = this._s.MoveNext();
      if (((int) nullable1.GetValueOrDefault() != 91 ? 1 : (!nullable1.HasValue ? 1 : 0)) != 0)
        throw new ArgumentException(this._s.GetDebugString(AtlasWeb.JSON_InvalidArrayStart));
      bool flag = false;
      char? nextNonEmptyChar;
      char? nullable2;
      do
      {
        char? nullable3 = nextNonEmptyChar = this._s.GetNextNonEmptyChar();
        if ((nullable3.HasValue ? new int?((int) nullable3.GetValueOrDefault()) : new int?()).HasValue)
        {
          char? nullable4 = nextNonEmptyChar;
          if (((int) nullable4.GetValueOrDefault() != 93 ? 1 : (!nullable4.HasValue ? 1 : 0)) != 0)
          {
            this._s.MovePrev();
            object obj = this.DeserializeInternal(depth);
            list.Add(obj);
            flag = false;
            nextNonEmptyChar = this._s.GetNextNonEmptyChar();
            char? nullable5 = nextNonEmptyChar;
            if (((int) nullable5.GetValueOrDefault() != 93 ? 0 : (nullable5.HasValue ? 1 : 0)) == 0)
            {
              flag = true;
              nullable2 = nextNonEmptyChar;
            }
            else
              goto label_8;
          }
          else
            goto label_8;
        }
        else
          goto label_8;
      }
      while (((int) nullable2.GetValueOrDefault() != 44 ? 1 : (!nullable2.HasValue ? 1 : 0)) == 0);
      throw new ArgumentException(this._s.GetDebugString(AtlasWeb.JSON_InvalidArrayExpectComma));
     label_8:
      if (flag)
        throw new ArgumentException(this._s.GetDebugString(AtlasWeb.JSON_InvalidArrayExtraComma));
      char? nullable6 = nextNonEmptyChar;
      if (((int) nullable6.GetValueOrDefault() != 93 ? 1 : (!nullable6.HasValue ? 1 : 0)) != 0)
        throw new ArgumentException(this._s.GetDebugString(AtlasWeb.JSON_InvalidArrayEnd));
      else
        return list;
    }
