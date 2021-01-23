    var prodForn = from produtosFornecedores in ERPDAOManager.GetTable<ProdutosFornecedores>()
                                                       //Inner Join com Fornecedores
                                                       join fornecedores in ERPDAOManager.GetTable<Fornecedores>()
                                                            on produtosFornecedores.ID_FORNECEDORES equals fornecedores.ID
                                                       //Inner Join com Municipios
                                                       join municipios in ERPDAOManager.GetTable<Municipios>()
                                                           on fornecedores.ID_MUNICIPIOS equals municipios.ID
                                                       //Inner Join com UnidadesFederacao
                                                       join unidadesFederacao in ERPDAOManager.GetTable<UnidadesFederacao>()
                                                           on municipios.ID_UNIDADESFEDERACAO equals unidadesFederacao.ID
                                                       //Filtros
                                                       where produtosFornecedores.ID_PRODUTOS == Convert.ToInt32(objEsquemasCalculoRegras.CD_OBJETO1) &&
                                                             produtosFornecedores.ID_PRODUTOSCONFIGPRECOS == Convert.ToInt32(objEsquemasCalculoRegras.CD_OBJETO2) &&
                                                             produtosFornecedores.FG_STATUS == true
                                                       group produtosFornecedores by new
                                                       {
                                                           ID_IMPOSTOSDESTINOS = fornecedores.ID_IMPOSTOSDESTINOS,
                                                           ID_FORNECEDORES = fornecedores.ID,
                                                           CD_UF_BASE = unidadesFederacao.CD_UNIDADEFEDERACAO,
                                                           produtosFornecedores.ID_PRODUTOS,
                                                           produtosFornecedores.ID_PRODUTOSCONFIGPRECOS
                                                       } into grpProdutosFornecedores
                                                       select new
                                                       {
                                                           grpProdutosFornecedores.Key.ID_IMPOSTOSDESTINOS,
                                                           grpProdutosFornecedores.Key.ID_FORNECEDORES,
                                                           grpProdutosFornecedores.Key.CD_UF_BASE,
                                                           NM_PRECO_REPOSICAO = (decimal)grpProdutosFornecedores.Max(item => item.NM_PRECO_REPOSICAO),
                                                           ID_MOEDAS_REPOSICAO = (int)grpProdutosFornecedores.Max(item => item.ID_MOEDAS_REPOSICAO),
                                                           ID_IMPOSTOSCONFIG = (int)grpProdutosFornecedores.Max(item => item.ID_IMPOSTOSCONFIG),
                                                           ID_TABELANCMS = (int)grpProdutosFornecedores.Max(item => item.ID_TABELANCMS)
                                                       };
                                        if (prodForn.Count() > 0)
                                        {
                                            NM_VALOR1 = prodForn.First().NM_PRECO_REPOSICAO;
                                            NM_VALOR2 = prodForn.First().ID_MOEDAS_REPOSICAO;
                                            ID_IMPOSTOSDESTINOS = prodForn.First().ID_IMPOSTOSDESTINOS;
                                            ID_IMPOSTOSCONFIG = prodForn.First().ID_IMPOSTOSCONFIG;
                                            ID_TABELANCMS = prodForn.First().ID_TABELANCMS;
                                            ID_FORNECEDORES = prodForn.First().ID_FORNECEDORES;
                                            CD_UF_BASE = prodForn.First().CD_UF_BASE;
                                        }
