     vendorProducts = (from vp in db.COMPANIES_VND_PRODUCTS
                        join p in db.CT_CT_INV_CLASSES on vp.CLASS_ID equals p.CLASS_ID
                        join m in db.CT_CT_MODALITY_CODES on vp.MODALITY_ID equals m.MODALITY_ID
                        where vp.COMPANY_ID == companyId
                        select new ProductTypeModality
                        {
                          Active = p.ACTIVE.Equals("Y") ? true : false,
                          BioMedImaging = p.BIOMED_IMAGING,
                          Code = p.CLASS_CODE,
                          Description = p.DESCRIPTION,
                          Id = p.CLASS_ID,
                          PricingMargin = p.PRICING_MARGIN,
                          ModalityCode = m.MODALITY_CODE,
                          ModalityId = m.MODALITY_ID,
                          VendorId = companyId
                        }).OrderBy(x => x.Code).ToList<ProductTypeModality>();
