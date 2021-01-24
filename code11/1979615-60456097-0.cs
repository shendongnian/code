            public virtual void WriteSaveXmlData(string pPath, int pRoom, bool pNewGame, int pX, int pY)
        {
            //xml save serialization
            XmlSaving XmlGameSave = new XmlSaving();
            XmlGameSave.SaveRootPath = pPath;
            XmlGameSave.SavedCurrentRoom = pRoom;
            XmlGameSave.XmlIsNewGame = pNewGame;
            XmlGameSave.XHero = pX;
            XmlGameSave.YHero = pY;
            XmlSerializer xs = new XmlSerializer(typeof(XmlSaving));
            using (StreamWriter wr = new StreamWriter(GameRound.GameSaveRootPath + GameRound.SaveFileName))
            {
                xs.Serialize(wr, XmlGameSave);
            }
        }
        public virtual XmlSaving ReadSaveXmlData()
        {
            //xml save deserialization
            XmlSerializer xs = new XmlSerializer(typeof(XmlSaving));
            using (StreamReader rd = new StreamReader(GameRound.GameSaveRootPath + GameRound.SaveFileName))
            {
                XmlSaving XmlGameSave = xs.Deserialize(rd) as XmlSaving;
                return XmlGameSave;
            }
        }
        public virtual XmlMap ReadXmlMapData(string pPath, int RoomNumber)
        {
            
            XmlMap ReadTmxData = new XmlMap();
            XmlSerializer TmxXmlMap = new XmlSerializer(typeof(XmlMap));
            using (StreamReader rd = new StreamReader(pPath + @"P1\RoomMapSaphir0" + RoomNumber + ".tmx"))
            {
                ReadTmxData = TmxXmlMap.Deserialize(rd) as XmlMap;
                return ReadTmxData;
            }
            
            
        }
