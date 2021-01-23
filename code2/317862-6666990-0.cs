    ALTER Procedure [dbo].[sp_tblAsnad_SelectAllForReport]
    @where nvarchar(max)
    As
    Begin                                       
    Select
            ta.IdMoinRef,
            ta.IdTafzeliRef,
            ta.ShHesab,
            ta.Bd,
            ta.Bs,
            ta.ShSnd,
            ta.AtfSnd,
            ta.DateSnd,
            mo.Hmoin,
            co.Hcol,
            gr.Hgroup,
            co.IdGroupRef,
            mo.IdColRef
        From tblAsnad as ta
        inner join tblMoin as mo on ta.IdMoinRef=mo.IdMoin
        inner join tblCol as co on mo.IdColRef=co.IdCol
        inner join tblGroup as gr on co.IdGroupRef=gr.IdGroup
        exec('WHERE ta.IdMoinRef in(112,113,115)')
    End
