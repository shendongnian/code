    var result = db.Set<NettingAgreementEntity>()
        .Selec(nae => new NettingAgreementEntityDto
        {
            Id = nae.EntityId,
            EntityName = nae.EntityName,
            DocType = nae.DocType,
            Jurisdiction = nae.Jurisdiction,
            ProductList = nae.Opinions
                .Select(no => new NettingAgreementProductDto
                {
                    no.Product.Id,
                    no.Product.Name,
                }).ToList(),
        });
 
