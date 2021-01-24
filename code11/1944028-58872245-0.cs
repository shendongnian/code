public T Dequeue()
{
	if (_size == 0)
	{
		ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EmptyQueue);
	}
	T result = _array[_head];
	_array[_head] = default(T);
	_head = (_head + 1) % _array.Length;
	_size--;
	_version++;
	return result;
}
