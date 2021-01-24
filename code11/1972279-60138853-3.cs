    List<ViewParceirosModel> viewParceiroModels = Usarios
        .Where(usario => usario.Perfil == RoleType.Parceirdo)
        .Select(usario => new ViewParceirosModel
        {
            Id = x.id,
            NomeParceiro = x.nome,
            EmailAcesso = x.email,
        }
        .OrderBy(viewParceirosModel => viewParceirosModel.NomeParceiro)
        .ToList();
