    public List<MemberViewModel> ListNewMember(int top, string languageId)
            {
                
                if (languageId == "en")
                {
                    IEnumerable<MemberViewModel> model1 = from a in db.Members
                                join b in db.Members
                                on a.MemberId equals b.MemberId
                                select new MemberViewModel()
                                {
                                    MemberId = a.MemberId,
                                    Name = b.EnglishName,
                                    Status = a.Status,
                                    Logo = a.Logo,
                                    Email = a.Email,
                                    Address = a.Address,
                                    Banner = a.Banner,
                                    Facebook = a.Facebook,
                                    Description = a.EnglishDescription
                                };
                    model1 = model1.Where(x => x.Status == true).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
                }
    
                IEnumerable<MemberViewModel> model2 = from a in db.Members
                            join b in db.Members
                            on a.MemberId equals b.MemberId
                            select new MemberViewModel()
                            {
                                MemberId = a.MemberId,
                                Name = b.Name,
                                Status = a.Status,
                                Logo = a.Logo,
                                Email = a.Email,
                                Address = a.Address,
                                Banner = a.Banner,
                                Facebook = a.Facebook,
                                Description = a.Description
                            };
                return model2.Where(x => x.Status == true).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
            }
