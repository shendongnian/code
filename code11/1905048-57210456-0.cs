    var configuration = new MapperConfiguration(
         cfg => cfg.CreateMap<OrderLineRequest, OrderLine>()
            .ForMember(d => d.Barcodes, opt => opt.Ignore())
            .ForSourceMember(s => s.Barcode1, opt => opt.DoNotValidate())
            .ForSourceMember(s => s.Barcode2, opt => opt.DoNotValidate())
            .ForSourceMember(s => s.Barcode3, opt => opt.DoNotValidate())
            .AfterMap((source, destination) =>
            {
                destination.Barcodes = new List<Barcode>
                {
                    new Barcode { Code = source.Barcode1 }
                };
                if (source.Barcode2 != null)
                    destination.Barcodes.Add(new Barcode { Code = source.Barcode2 });
                if (source.Barcode3 != null)
                    destination.Barcodes.Add(new Barcode { Code = source.Barcode3 });
            }));
