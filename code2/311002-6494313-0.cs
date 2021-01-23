      private void validateData(Long memberId) {
           //Pseudo code Depends on how you are connecting to your database...
           SQLQuery query = getQuery("existsMemberId");
           query.setParameter("memberId");
           executeQuery(query);
           // If the query returns something then the reference exists and it is ok to proceed
      }
