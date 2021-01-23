    using (SqlConnection conn = ...)
    using (SqlCommand chkdt = ...)
    {
       ...
       using (SqlDataReder reader = ...)
       {
          ...
       }
    }
