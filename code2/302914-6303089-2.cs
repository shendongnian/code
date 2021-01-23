    public IQueryable<TabMasterViewModel> Query(Expression<Func<TabMaster, bool>> whereCondition)
            {
                IQueryable<TabMaster> tabmasters = _tabmasterRepository.GetQueryable().Where(whereCondition);
                
                AutoMapper.Mapper.CreateMap<TabMaster, TabMasterViewModel>()
                      .ForMember(dest => dest.colID, opt => opt.MapFrom(src => src.colID));
                return AutoMapper.Mapper.Map<IQueryable<TabMaster>,  IQueryable<TabMasterViewModel>> (tabmasters);            
            }
