    public void PostProcessPayment(PostProcessPaymentRequest postProcessPaymentRequest)
    {
          // some code
          string url = protocol + host + "/" + "PaymentCODBooking/ProcessInternetPayment";
        _httpContextAccessor.HttpContext.Response.Redirect(url);
        return;
    }
