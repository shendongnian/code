    JavaScriptSerializer ser = new JavaScriptSerializer();
            
    
            string final_sb = sb.ToString();
    
            List<Class3.ListWrapper_Main> movieInfos = ser.Deserialize<List<Class3.ListWrapper_Main>>(final_sb.ToString());
            
            foreach (var itemdetail in movieInfos)
            {
    
                foreach (var itemdetail2 in itemdetail.ResultList)
                {
                    Response.Write("channelType=" + itemdetail2.channelType + "<br/>");
                    Response.Write("duration=" + itemdetail2.duration + "<br/>");
                    Response.Write("episodeno=" + itemdetail2.episodeno + "<br/>");
                    Response.Write("genre=" + itemdetail2.genre + "<br/>");
    
                    string[] genreList_arr = itemdetail2.genreList;
                    for (int i = 0; i < genreList_arr.Length; i++)
                        Response.Write("genreList1=" + genreList_arr[i].ToString() + "<br>");
    
                    foreach (var genres1 in itemdetail2.genres)
                    {
                        Response.Write("genres1=" + genres1.personName + "<br>");
                    }
    
                    Response.Write("id=" + itemdetail2.id + "<br/>");
                    Response.Write("imageUrl=" + itemdetail2.imageUrl + "<br/>");
                    //Response.Write("imageurl=" + itemdetail2.imageurl + "<br/>");
                    Response.Write("language=" + itemdetail2.language + "<br/>");
                    Response.Write("name=" + itemdetail2.name + "<br/>");
                    Response.Write("productId=" + itemdetail2.productId + "<br/>");
                    Response.Write("productMasterId=" + itemdetail2.productMasterId + "<br/>");
                    Response.Write("productMasterName=" + itemdetail2.productMasterName + "<br/>");
                    Response.Write("productName=" + itemdetail2.productName + "<br/>");
                    Response.Write("productTypeId=" + itemdetail2.productTypeId + "<br/>");
                    Response.Write("productTypeName=" + itemdetail2.productTypeName + "<br/>");
                    Response.Write("rating=" + itemdetail2.rating + "<br/>");
                    Response.Write("releaseYear=" + itemdetail2.releaseYear + "<br/>");
                    //Response.Write("releaseyear=" + itemdetail2.releaseyear + "<br/>");
                    Response.Write("showGoodName=" + itemdetail2.showGoodName + "<br/>");
                    Response.Write("views=" + itemdetail2.views + "<br/><br>");
                    //Response.Write("resultSize" + itemdetail2.resultSize + "<br/>");
                    //  Response.Write("pageIndex" + itemdetail2.pageIndex + "<br/>");
          
    
                }
    
    
    
                Response.Write("resultSize=" + itemdetail.resultSize + "<br/><br>");
                Response.Write("pageIndex=" + itemdetail.pageIndex + "<br/><br>");
    
            }
    
    
