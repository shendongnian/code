    var ans = imisContext.TblFamilies
                         .Join(imisContext.TblInsuree,
                             f => f.InsureeId,
                             i => i.InsureeId,
                             (f, i) => new { TblFamilies = f, TblInsuree = i })
                         .Join(imisContext.TblLocations,
                             fi => fi.TblFamilies.LocationId,
                             l => l.LocationId,
                             (fi, l) => new { fi.TblFamilies, fi.TblInsuree, TblLocations = l })
                         .Join(imisContext.TblConfirmationTypes,
                             fil => fil.TblFamilies.ConfirmationType,
                             c => c.ConfirmationType,
                             (fil, c) => new { fil.TblFamilies, fil.TblInsuree, fil.TblLocations, TblConfirmationTypes = c })
                         .Join(imisContext.TblFamilyTypes,
                             filc => filc.TblFamilies.FamilyType,
                             ft => ft.FamilyType,
                             (filc, ft) => new { filc.TblFamilies, filc.TblInsuree, filc.TblLocations, filc.TblConfirmationTypes, TblFamilyTypes = ft })
                         .Join(imisContext.TblProfessions,
                             filcft => filcft.TblInsuree.Profession,
                             p => p.ProfessionId,
                             (filcft, p) => new { filcft.TblFamilies, filcft.TblInsuree, filcft.TblLocations, filcft.TblConfirmationTypes, filcft.TblFamilyTypes, TblProfessions = p })
                         .Join(imisContext.TblHf,
                             c => c.TblInsuree.Hfid,
                             h => h.HfId,
                             (filcftp, h) => new { filcftp.TblFamilies, filcftp.TblInsuree, filcftp.TblLocations, filcftp.TblConfirmationTypes, filcftp.TblFamilyTypes,filcftp.TblProfessions, TblHf = h })
                         .Where(filcftph => filcftph.TblInsuree.Hfid == insureeNumberINT);
