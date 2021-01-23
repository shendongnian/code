    foreach (var g in DistinctGenres)
    {
        FileStream fs = new FileStream(cPath + Path.DirectorySeparatorChar + g.Genre, FileMode.Create);
        StreamWriter genStream = new StreamWriter(fs);
        // Write your header here
        
        foreach (var m in Genres)
        {
            // Generates the HTML for the Movie
            
            // Writes the HTML to the stream
            genStream.WriteLine(strMovie);
            lineID = lineID == 0 ? 1 : 0;
        }
        string closingHTML = "      </table>\r\n" + "   </body>\r\n" + "</html>";
        genStream.WriteLine(closingHTML);
        genStream.Close();
    }
