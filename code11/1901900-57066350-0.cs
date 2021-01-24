namespace Simple.Data.Pagination.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    /// <summary>
    /// Provides some extension methods for <see cref="IEnumerable{T}" /> to provide paging capability.
    /// </summary>
    public static class EnumerablePagedListExtensions
    {
        /// <summary>
        /// Converts the specified source to <see cref="IPagedList{T}" /> by the specified <paramref name="pageIndex" /> and
        /// <paramref name="pageSize" />.
        /// </summary>
        /// <typeparam name="T">The type of the source.</typeparam>
        /// <param name="source">The source to paging.</param>
        /// <param name="pageIndex">The index of the page.</param>
        /// <param name="pageSize">The size of the page.</param>
        /// <param name="indexFrom">The start index value.</param>
        /// <param name="totalCount">The Total Count</param>
        /// <returns>An instance of the inherited from <see cref="IPagedList{T}" /> interface.</returns>
        public static IPagedList<T> ToPagedList<T>(this IEnumerable<T> source, int pageIndex, int pageSize, int indexFrom = 0, int totalCount = 0) => new PagedList<T>(source, pageIndex, pageSize, totalCount);
        /// <summary>
        /// Converts the specified source to <see cref="IPagedList{T}" /> by the specified <paramref name="pageIndex" /> and
        /// <paramref name="pageSize" />.
        /// </summary>
        /// <typeparam name="T">The type of the source.</typeparam>
        /// <param name="source">The source to paging.</param>
        /// <param name="pageIndex">The index of the page.</param>
        /// <param name="pageSize">The size of the page.</param>
        /// <param name="indexFrom">The start index value.</param>
        /// <returns>An instance of the inherited from <see cref="IPagedList{T}" /> interface.</returns>
        public static IPagedList<T> ToPagedList<T>(this IQueryable<T> source, int pageIndex, int pageSize, int indexFrom = 0) => new PagedList<T>(source, pageIndex, pageSize, indexFrom);
        /// <summary>
        /// Converts the specified source to <see cref="IPagedList{T}" /> by the specified <paramref name="converter" />,
        /// <paramref name="pageIndex" /> and <paramref name="pageSize" />
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TResult">The type of the result</typeparam>
        /// <param name="source">The source to convert.</param>
        /// <param name="converter">The converter to change the <typeparamref name="TSource" /> to <typeparamref name="TResult" />.</param>
        /// <param name="pageIndex">The page index.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="indexFrom">The start index value.</param>
        /// <returns>An instance of the inherited from <see cref="IPagedList{T}" /> interface.</returns>
        public static IPagedList<TResult> ToPagedList<TSource, TResult>(this IEnumerable<TSource> source,
            Func<IEnumerable<TSource>, IEnumerable<TResult>> converter, int pageIndex, int pageSize,
            int indexFrom = 0) => new PagedList<TSource, TResult>(source, converter, pageIndex, pageSize, indexFrom);
    }
}
namespace Simple.Data.Pagination.Extensions
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    /// <summary>
    /// Extensions for the <see cref="IPagedList{T}"/>
    /// </summary>
    public static class QueryablePageListExtensions
    {
        /// <summary>
        /// Converts the specified source to <see cref="IPagedList{T}" /> by the specified <paramref name="pageIndex" /> and <paramref name="pageSize" />
        /// </summary>
        /// <typeparam name="T">The type of the source</typeparam>
        /// <param name="source">The source to paging</param>
        /// <param name="pageIndex">The index of the page</param>
        /// <param name="pageSize">The size of the page</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete</param>
        /// <param name="indexFrom">The start index value</param>
        /// <returns>An instance of the inherited from <see cref="IPagedList{T}"/> interface</returns>
        public static async Task<IPagedList<T>> ToPagedListAsync<T>(this IQueryable<T> source, int pageIndex, int pageSize, int indexFrom = 0, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (indexFrom > pageIndex)
            {
                throw new ArgumentException($"indexFrom: {indexFrom} > pageNumber: {pageIndex}, must indexFrom <= pageNumber");
            }
            var count = await source.CountAsync(cancellationToken).ConfigureAwait(false);
            var items = await source.Skip((pageIndex - indexFrom) * pageSize).Take(pageSize).ToListAsync(cancellationToken).ConfigureAwait(false);
            var pagedList = new PagedList<T>
            {
                PageNumber = pageIndex,
                PageSize = pageSize,
                IndexFrom = indexFrom,
                TotalCount = count,
                Items = items,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize)
            };
            return pagedList;
        }
    }
}
namespace Simple.Data.Pagination.Interfaces
{
    using System.Collections.Generic;
    /// <summary>
    /// Provides the interface(s) for paged list of any type
    /// </summary>
    /// <typeparam name="T">The type for paging.</typeparam>
    public interface IPagedList<T>
    {
        /// <summary>
        /// Gets the Index Start Value
        /// </summary>
        int IndexFrom { get; }
        /// <summary>
        /// Gets the Page Number
        /// </summary>
        int PageNumber { get; }
        /// <summary>
        /// Gets the Page Size
        /// </summary>
        int PageSize { get; }
        /// <summary>
        /// Gets the Total Count of the list of <typeparamref name="T" />
        /// </summary>
        int TotalCount { get; }
        /// <summary>
        /// Gets the Total Pages
        /// </summary>
        int TotalPages { get; }
        /// <summary>
        /// Gets the Current Page Items
        /// </summary>
        IList<T> Items { get; }
        /// <summary>
        /// Gets a value indicating whether the paged list has a previous page
        /// </summary>
        bool HasPreviousPage { get; }
        /// <summary>
        /// Gets a value indicating whether the paged list has a next page
        /// </summary>
        bool HasNextPage { get; }
    }
}
namespace Simple.Data.Pagination
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    /// <summary>
    /// Represents the default implementation of the <see cref="IPagedList{T}" /> interface
    /// </summary>
    /// <typeparam name="T">The type of the data to page</typeparam>
    public class PagedList<T> : IPagedList<T>
    {
        /// <inheritdoc />
        public int PageNumber { get; set; }
        /// <inheritdoc />
        public int PageSize { get; set; }
        /// <inheritdoc />
        public int TotalCount { get; set; }
        /// <inheritdoc />
        public int TotalPages { get; set; }
        /// <inheritdoc />
        public int IndexFrom { get; set; }
        /// <inheritdoc />
        public IList<T> Items { get; set; }
        /// <inheritdoc />
        public bool HasPreviousPage => this.PageNumber - this.IndexFrom > 0;
        /// <inheritdoc />
        public bool HasNextPage => this.PageNumber - this.IndexFrom + 1 < this.TotalPages;
        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{T}" /> class.
        /// </summary>
        /// <param name="source">The Source Collection</param>
        /// <param name="pageNumber">The Page Number</param>
        /// <param name="pageSize">The Page Size</param>
        /// <param name="totalCount">The Total Item Count</param>
        public PagedList(IEnumerable<T> source, int pageNumber, int pageSize, int totalCount)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.IndexFrom = pageNumber * pageSize;
            var itemList = source.ToList();
            this.TotalCount = totalCount;
            this.TotalPages = (int)Math.Ceiling(this.TotalCount / (double)this.PageSize);
            this.Items = itemList.Skip(this.IndexFrom).Take(this.PageSize).ToList();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{T}" /> class
        /// </summary>
        /// <param name="source">The Source Collection</param>
        /// <param name="pageNumber">The Page Number</param>
        /// <param name="pageSize">The Page Size</param>
        public PagedList(IQueryable<T> source, int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.IndexFrom = pageNumber * pageSize;
            this.TotalCount = source.Count();
            this.TotalPages = (int)Math.Ceiling(this.TotalCount / (double)this.PageSize);
            this.Items = source.Skip(this.IndexFrom).Take(this.PageSize).ToList();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{T}" /> class
        /// </summary>
        public PagedList()
        {
            this.Items = new T[0];
        }
    }
    /// <summary>
    /// Provides the implementation of the <see cref="IPagedList{T}" /> and Converter
    /// </summary>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public class PagedList<TSource, TResult> : IPagedList<TResult>
    {
        /// <inheritdoc />
        public int PageNumber { get; }
        /// <inheritdoc />
        public int PageSize { get; }
        /// <inheritdoc />
        public int TotalCount { get; }
        /// <inheritdoc />
        public int TotalPages { get; }
        /// <inheritdoc />
        public int IndexFrom { get; }
        /// <inheritdoc />
        public IList<TResult> Items { get; }
        /// <inheritdoc />
        public bool HasPreviousPage => this.PageNumber - this.IndexFrom > 0;
        /// <inheritdoc />
        public bool HasNextPage => this.PageNumber - this.IndexFrom + 1 < this.TotalPages;
        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{TSource, TResult}" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="converter">The converter.</param>
        /// <param name="pageIndex">The index of the page.</param>
        /// <param name="pageSize">The size of the page.</param>
        /// <param name="indexFrom">The index from.</param>
        public PagedList(IEnumerable<TSource> source, Func<IEnumerable<TSource>, IEnumerable<TResult>> converter, int pageIndex, int pageSize, int indexFrom)
        {
            if (source is IQueryable<TSource> queryable)
            {
                this.PageNumber = pageIndex;
                this.PageSize = pageSize;
                this.IndexFrom = indexFrom;
                this.TotalCount = queryable.Count();
                this.TotalPages = (int)Math.Ceiling(this.TotalCount / (double)this.PageSize);
                var items = queryable.Skip((this.PageNumber - this.IndexFrom) * this.PageSize).Take(this.PageSize).ToArray();
                this.Items = new List<TResult>(converter(items));
            }
            else
            {
                this.PageNumber = pageIndex;
                this.PageSize = pageSize;
                this.IndexFrom = indexFrom;
                var itemList = source.ToList();
                this.TotalCount = itemList.Count;
                this.TotalPages = (int)Math.Ceiling(this.TotalCount / (double)this.PageSize);
                var items = itemList.Skip((this.PageNumber - this.IndexFrom) * this.PageSize).Take(this.PageSize).ToArray();
                this.Items = new List<TResult>(converter(items));
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{TSource, TResult}" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="converter">The converter.</param>
        public PagedList(IPagedList<TSource> source, Func<IEnumerable<TSource>, IEnumerable<TResult>> converter)
        {
            this.PageNumber = source.PageNumber;
            this.PageSize = source.PageSize;
            this.IndexFrom = source.IndexFrom;
            this.TotalCount = source.TotalCount;
            this.TotalPages = source.TotalPages;
            this.Items = new List<TResult>(converter(source.Items));
        }
    }
    /// <summary>
    /// Provides some help methods for <see cref="IPagedList{T}" /> interface.
    /// </summary>
    public static class PagedList
    {
        /// <summary>
        /// Creates an empty of <see cref="IPagedList{T}" />.
        /// </summary>
        /// <typeparam name="T">The type for paging</typeparam>
        /// <returns>An empty instance of <see cref="IPagedList{T}" />.</returns>
        public static IPagedList<T> Empty<T>() => new PagedList<T>();
        /// <summary>
        /// Creates a new instance of <see cref="IPagedList{TResult}" /> from source of <see cref="IPagedList{TSource}" />
        /// instance.
        /// </summary>
        /// <typeparam name="TResult">The Type of the Result</typeparam>
        /// <typeparam name="TSource">The Type of the Source</typeparam>
        /// <param name="source">The Source</param>
        /// <param name="converter">The Converter</param>
        /// <returns>An instance of <see cref="IPagedList{TResult}" />.</returns>
        public static IPagedList<TResult> From<TResult, TSource>(IPagedList<TSource> source, Func<IEnumerable<TSource>, IEnumerable<TResult>> converter) => new PagedList<TSource, TResult>(source, converter);
    }
}
