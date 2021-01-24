    public class DvdController 
    {
        public List<DVD> GetDvdsAuthors()
        {
            var dvds = DvdRepository.GetDvds();
            var authors = DvdRepository.GetAuthorsForDvds(Dvds);
            var DvdsWithAuthors = Views.GetDvdView(dvds, authors);
         }
    }
