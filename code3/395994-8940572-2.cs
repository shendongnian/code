    try     
    {    
        if (e.Row.RowType == DataControlRowType.DataRow)    
        {    
            // Please note: the value in Cells has changed for my testing data.    
            LinkButton btn = (LinkButton)e.Row.Cells[2].FindControl("lnkBtnEdit");    
    
            btn.Attributes.Add("onclick", "javascript:alert('Single Click');");    
    
            LinkButton btnDouble = (LinkButton)e.Row.Cells[2].FindControl("lnkBtnEditDouble");    
    
            btnDouble.Attributes.Add("onclick", "javascript:clickCounter();");    
        }    
    }    
    catch (Exception ex)    
    {    
        Console.WriteLine(ex.Message);    
    }    
    
