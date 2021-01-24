    class Logger {
        // If you want personalized messages for different actions or origins, define their template constants and create different methods for building them. 
        public const string ORDER_PROGRESS_MSG_TMPL = "Action:{0}, Origin:{1}, OrderId:{3}";
        void log_order_progress(string actionName, sting actionOrigin, string orderId){
            Console.WriteLine(
                ORDER_PROGRESS_MSG_TMPL, actionName, actionOrigin, orderId
            );
        }
    }
