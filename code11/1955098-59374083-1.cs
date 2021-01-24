    public List<MemberViewModel> ListNewMember(int top, string languageId)
            {
    
                if (languageId == "en")
                {
                    IEnumerable<MemberViewModel> model = from a in db.Members
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
                                    Description = b.EnglishDescription
                                };
                    model = model.Where(x => x.Status == true).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
                    return model.Where(x => x.Status == true).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
                }
                else
                {
                    IEnumerable<MemberViewModel> model = from a in db.Members
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
                    model = model.Where(x => x.Status == true).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
                    return model.Where(x => x.Status == true).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
                }
                
            }
