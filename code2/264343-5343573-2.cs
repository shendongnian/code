    MessageQueue queue = ...
    TimeSpan timeout = TimeSpan.FromMilliseconds(100); // Small timeout - can be very small
    Message message = queue.Receive(timeout);
    while (message != null)
    {
          // Process message...
          message = queue.Receive(timeout);
    }
