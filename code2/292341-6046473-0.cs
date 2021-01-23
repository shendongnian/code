    try
            {
                /* *** actual processing specific to each method goes here *** */
            }
            catch (FaultException<CustomException> cfex)
            {
                // common stuff
            }
            catch (CustomException cfex)
            {
                // common stuff
            }
            catch (Exception ex)
            {
                // common stuff
            }
            finally
            {
                FinalizeServiceCall(wsBus, wsMessage, response, logProps);
            }
