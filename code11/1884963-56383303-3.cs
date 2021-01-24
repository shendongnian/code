        public Profile()
        {
          CreateMap<PositionDto, OrderLine>()
            .ForMember(dest => dest, opt => opt.ResolveUsing<OrderResolver>());
        }
      }
    }
