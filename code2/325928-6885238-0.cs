    public class OrderProcessor {
      protected final List<OrderProcessorListener> listeners = new ArrayList<OrderProcessorListener>();
      public void addListener(OrderProcessorListener orderProcessorListener) {
        listeners.add(orderProcessorListener);
      }
      public void notifyListeners(OrderProcessorEvent event) {
        for(OrderProcessorListener listener : listeners) {
          listener.handle(event);
        }
      }
      public void randomMethod() {
        // ... do stuff
        notifyListeners(new SomeEvent(...)); // notify listeners
      }
      public interface OrderProcessorListener {
        public void handle(OrderProcessorEvent event);
      }
    }
