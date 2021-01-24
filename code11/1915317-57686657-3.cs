        var humanEntity = new List<HomaEntity> {
            new HomaEntity{ Id = "T1", Humans = new List<HumanEntity>(){
                new HumanEntity{ Id = "H1"},
            } },
            new HomaEntity{ Id = "TT1", Humans = new List<HumanEntity>(){
                new HumanEntity{ Id = "HH1"},
                new HumanEntity{ Id = "HH2"},
            } },
            new HomaEntity{ Id = "TT1", Humans = new List<HumanEntity>(){
                new HumanEntity{ Id = "HHH1"},
                new HumanEntity{ Id = "HHH2"},
                new HumanEntity{ Id = "HHH3"}
            } }
        };
        // Here it throws the exception
        var homeViewModels = _mapper.Map<List<HomeViewModel>>(humanEntity);
