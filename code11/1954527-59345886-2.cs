        ListNode current;
        ListNode l1 = a;
        ListNode l2 = b;
        ListNode result; // here we save the former result.next as result
    
        if (l1!=null && l2!=null)
        {
            if(l1.val < l2.val) 
            { 
                result = l1; 
                current = l1 = l1.next;
            }
            else 
            {
                result = l2;
                current = l2 = l2.next;
            }
        }
            
        
        while ( ....)
        {
             /* unmodified */
        }
        return result;
