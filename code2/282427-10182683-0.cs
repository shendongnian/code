    try{
     if(orderService.TryCreateOrder(orderData)){
       if(reservationService.TryMakeReservation(orderData)){
          reservationService.Commit();
          orderService.Commit();
       }
       else{
         orderService.TryRollbackOrder(orderData);
         throw new ReservationCouldNotBeMadeException();
       }
     }
     else{
      throw new OrderCouldNotBeCreatedException();
     }
    }
    catch(CouldNotRollbackOrderServiceException){
     // do something here...
    }
    catch(CouldNotCommitServiceException){
     // do something here...
    }
