            // obtenir la CollectionView 
            ICollectionView cvCollectionView = CollectionViewSource.GetDefaultView(this.Suivis);
            if (cvCollectionView == null)
                return;
            // filtrer ... exemple pour tests DI-2015-05105-0
            cvCollectionView.Filter = p_oObject => { return true; /* use your own filter */ };
            // page configuration
            int iMaxItemPerPage = 2;
            int iCurrentPage = 0;
            int iStartIndex = iCurrentPage * iMaxItemPerPage;
            // déterminer les objects "de la page"
            int iCurrentIndex = 0;
            HashSet<object> hsObjectsInPage = new HashSet<object>();
            foreach (object oObject in cvCollectionView)
            {
                // break if MaxItemCount is reached
                if (hsObjectsInPage.Count > iMaxItemPerPage)
                    break;
                // add if StartIndex is reached
                if (iCurrentIndex >= iStartIndex)
                    hsObjectsInPage.Add(oObject);
                // increment
                iCurrentIndex++;
            }
            // refilter
            cvCollectionView.Filter = p_oObject =>
            {
                return hsObjectsInPage.Contains(p_oObject);
            };
