        // Add this check before the assign step...
        if ((this._commandCollection == null)) this.InitCommandCollection();
        for (int i = 0; i < this._commandCollection.Length; i++)
        {
           if ((this._commandCollection[i] != null))
           {
              ((System.Data.SqlClient.SqlCommand)
              (this._commandCollection[i])).CommandTimeout = value;
           }
        }
       }
     }
