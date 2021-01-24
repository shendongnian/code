    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private T currentItem;
        private DoublyLinkedList<T> previousItem;
        private DoublyLinkedList<T> nextItem;
    
        public DoublyLinkedList(T cItem, DoublyLinkedList<T> pItem, DoublyLinkedList<T> nItem)
        {
            currentItem = cItem;
            previousItem = pItem;
            nextItem = nItem;
        }
