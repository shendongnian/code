        public Profile()
        {
          CreateMap<PositionDto, OrderLine>()
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Amount))
            .ForMember(dest => dest.DeliveryCondition, opt => opt.ResolveUsing<ConditionResolver>());
        }
      }
    }
