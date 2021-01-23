    using (IDataReader dr = DatabaseContext.ExecuteReader(command))
        {
            if (dr.HasRows)
            {
                AutoMapper.Mapper.CreateMap<IDataReader, ProductModel>();
                return AutoMapper.Mapper.Map<IDataReader, IList<ProductModel>>(dr);
            }
            return null;
        }
