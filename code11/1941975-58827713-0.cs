    public Picture GetIndividualPicture(int vehicleId_, int pictureId_)
        {
            IEnumerable<Picture> pictures =  from v in _vehicleContext.Pictures
                        .Include(vp => vp.Vehicle)
                        .Where(x => x.Vehicle.Id == vehicleId_
                                && x.Id == pictureId_) select v;    
            return pictures.FirstOrDefault();
        }
