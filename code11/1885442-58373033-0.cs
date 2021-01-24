    public ActionResult VendorDetails(string search,string sort,string filter,int? page_no)
        {
            ViewBag.CurrentSortOrder = sort;    
            ViewBag.NameSortParam = sort == "name" ? "name_desc" : "name";
            if (search != null)
            {
                page_no = 1;
            }
            else
            {
                search = filter;
            }
    
            ViewBag.FilterValue = search;
            var   ven = (from x in db.vendordetails
                       join y in db.ven_tax_information on x.ven_account equals y.ven_id
                        select new vendortotal()
                        {
                                ven_account=x.ven_account,
                                 ven_type=x.ven_type,
                                ven_name =x.ven_name,
                                ven_group=x.ven_group,
                                city  =x.city,
                                state=x.state,
                                country=x.country,
                                zipcode=x.zipcode,
                                contactname=x.contactname,
                                designation=x.designation,
                                contactno =x.contactno,
                                email=x.email,
                                tax_group =y.tax_group
                            });
            if (!String.IsNullOrEmpty(search))
                {
                    ven = ven.Where(x =>
                        (x.ven_name.Contains(search)) ||
                        (x.ven_type.Contains(search)) ||
                        (x.contactname.Contains(search))
                        );     
                }
          switch (sort)
                {
                    case "name_desc":
                    ven = ven.OrderByDescending(x => x.ven_name);
                        break;
                    case "name":
                        ven = ven.OrderBy(x => x.ven_name);
                        break;
                    case "search":
                        ven = ven.OrderBy(x => x.ven_account);
                        break;
                    default:
                        ven = ven.OrderBy(x => x.ven_account);
                        break;
                }
                int Size_Of_Page = 5;
                    int No_Of_Page = (page_no ?? 1);
                    return View(ven.ToPagedList(No_Of_Page, Size_Of_Page));
        }
