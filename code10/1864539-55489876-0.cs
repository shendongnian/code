      .Execute(() => {
           result = getNext()(input, getNext);
           if (result.Exception != null) {
              throw new Exception("Retry", result.Exception);
           }
      });
