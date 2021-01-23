    EntityConnectionStringBuilder conn = new EntityConnectionStringBuilder();
            conn.Metadata = @"res://*/KzDm.csdl|res://*/KzDm.ssdl|res://*/KzDm.msl";
            conn.Provider = "System.Data.SQLite";
            conn.ProviderConnectionString = @"data source=F:\My Own programs\KrarZara2\KZ\KZ\KrarDS.krar;Version=3;";
            EntityConnection entity = new EntityConnection(conn.ConnectionString);
            using (DmEnt ent = new DmEnt(entity))
            {
                var parcel = ent.Parcels.SingleOrDefault(d => d.id == 1);
                var pparcc = ent.Parcels.Select(d => d.id == 2);
                Parcel r = new Parcel();
                r.ParcelNumber = "11ju";
                r.Area = 8787;
                ent.AddToParcels(r);
                ent.SaveChanges();
            }
