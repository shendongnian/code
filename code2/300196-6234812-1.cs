    try {
        // your code here
    } finally {
        try {
            // if the code in finally can throw another exception, you need to catch it inside it
        } catch (Exception e) {
           // probably not much to do besides telling why it failed
        }
    } catch (Exception e) {
        try {
            // your error handling routine here
        } catch (Exception e) {
           // probably not much to do besides telling why it failed
        }
    }
